
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf.parser;
namespace SoftwareLF.Helpers
{
    class ExtraLocationExtractionStrategy : LocationTextExtractionStrategy
    {
        class ExtendedTextChunk : IComparable<ExtendedTextChunk>
        {
            internal TextChunk tchunk;
            internal LineSegment baseSegment;
            internal Rectangle rectangle;
            internal List<Rectangle> charRectangles;
            virtual public int CompareTo(ExtendedTextChunk rhs)
            {
                if (this == rhs) return 0; // not really needed, but just in case

                float y1 = this.baseSegment.GetStartPoint()[Vector.I2];
                float y2 = rhs.baseSegment.GetStartPoint()[Vector.I2];
                if (y1 != y2)
                {
                    var max = Math.Max(this.rectangle.Height, rhs.rectangle.Height);
                    if (Math.Abs(y1 - y2) >= 0.5 * max)
                        return y1 < y2 ? 1 : -1;
                    // else, are on the same logic line
                }
                return this.baseSegment.GetStartPoint()[Vector.I1] < rhs.baseSegment.GetStartPoint()[Vector.I1] ? -1 : 1;
            }
        }
        /** a summary of all found text */
        private List<ExtendedTextChunk> locationalResult = new List<ExtendedTextChunk>();
        private List<Rectangle> lineRectangles = new List<Rectangle>();

        private Rectangle getRectangle(TextRenderInfo renderInfo)
        {
            Vector lowerLine = renderInfo.GetDescentLine().GetStartPoint();
            Vector higherLine = renderInfo.GetAscentLine().GetEndPoint();

            var rect = new iTextSharp.text.Rectangle(lowerLine[Vector.I1],
                                                     lowerLine[Vector.I2],
                                                     higherLine[Vector.I1],
                                                     higherLine[Vector.I2]);


            return rect;
        }
        public override void RenderText(TextRenderInfo renderInfo)
        {
            LineSegment baseSegment = renderInfo.GetBaseline();
            if (renderInfo.GetRise() != 0)
            { // remove the rise from the baseline 
              // we do this because the text from a super/subscript render operations
              // should probably be considered as part of the baseline of the text the 
              // super /sub is relative to 
                Matrix riseOffsetTransform = new Matrix(0, -renderInfo.GetRise());
                baseSegment = baseSegment.TransformBy(riseOffsetTransform);
            }
            TextChunk location = new TextChunk(renderInfo.GetText(),
                                               baseSegment.GetStartPoint(),
                                               baseSegment.GetEndPoint(),
                                               renderInfo.GetSingleSpaceWidth());

            //Vector lowerLine = renderInfo.GetDescentLine().GetStartPoint();
            //Vector higherLine = renderInfo.GetAscentLine().GetEndPoint();
            //var rect = new iTextSharp.text.Rectangle(lowerLine[Vector.I1],
            //                                         lowerLine[Vector.I2],
            //                                         higherLine[Vector.I1],
            //                                         higherLine[Vector.I2]);
            var chunkrect = getRectangle(renderInfo);

            var charRectangles = new List<Rectangle>();
            foreach (var ri in renderInfo.GetCharacterRenderInfos())
            {
                charRectangles.Add(getRectangle(ri));
            }
            locationalResult.Add(new ExtendedTextChunk
            {
                tchunk = location,
                baseSegment = baseSegment,
                rectangle = chunkrect,
                charRectangles = charRectangles
            });
        }
        private bool StartsWithSpace(String str)
        {
            if (str.Length == 0)
                return false;
            return str[0] == ' ';
        }

        private bool EndsWithSpace(String str)
        {
            if (str.Length == 0) return false;
            return str[str.Length - 1] == ' ';
        }
        private string[] TextLines;
        public override string GetResultantText()
        {
            locationalResult.Sort();

            StringBuilder sb = new StringBuilder();
            ExtendedTextChunk lastChunk = null;
            float left = 0f, bottom = 0f, right = 0f, top = 0f;
            foreach (var chunk in locationalResult)
            {
                if (lastChunk == null)
                {
                    // save start & end coordinates
                    sb.Append(chunk.tchunk.Text);
                    left = chunk.rectangle.Left;
                    bottom = chunk.rectangle.Bottom;
                    right = chunk.rectangle.Right;
                    top = chunk.rectangle.Top;
                }
                else
                {
                    //if (chunk.tchunk.Text.StartsWith("19"))
                    //    continue;
                    if (SameLine(chunk, lastChunk))
                    {
                        //if (chunk.tchunk.Text.StartsWith("19"))
                        //    Console.WriteLine("Stop");

                        // we only insert a blank space if the trailing character of the 
                        // previous string wasn't a space, and the leading character of the 
                        // current string isn't a space

                        //IsChunkAtWordBoundary(chunk.tchunk, lastChunk.tchunk) && 

                        //if (!StartsWithSpace(chunk.tchunk.Text) &&
                        //    !EndsWithSpace(lastChunk.tchunk.Text))
                        //{
                        //}
                        float dist = Math.Abs(chunk.tchunk.DistanceFromEndOf(lastChunk.tchunk));
                        //float maxCharSpace = Math.Max(lastChunk.tchunk.CharSpaceWidth, chunk.tchunk.CharSpaceWidth);
                        //int spaces = (int)Math.Ceiling((decimal)(dist / maxCharSpace / 2));
                        float maxCharSpace = (lastChunk.tchunk.CharSpaceWidth + chunk.tchunk.CharSpaceWidth) / 2;  //tentative
                        int spaces = maxCharSpace == 0 ? 0 : (int)Math.Ceiling((decimal)(dist / maxCharSpace / 2)) - 1; // tentative -1
                        while (spaces > 0)
                        {
                            sb.Append(" ");
                            spaces--;
                        }

                        sb.Append(chunk.tchunk.Text);
                        // save Right coordinate - Keep minimum Bottom & maximum Top
                        right = chunk.rectangle.Right;
                        if (chunk.rectangle.Bottom < bottom) bottom = chunk.rectangle.Bottom;
                        if (chunk.rectangle.Top > top) top = chunk.rectangle.Top;
                    }
                    else
                    {
                        sb.Append("\n");
                        // generate line rectangle
                        lineRectangles.Add(new Rectangle(left, bottom, right, top));
                        sb.Append(chunk.tchunk.Text);

                        // save start & end coordinates
                        //sb.Append(chunk.tchunk.Text);
                        left = chunk.rectangle.Left;
                        bottom = chunk.rectangle.Bottom;
                        right = chunk.rectangle.Right;
                        top = chunk.rectangle.Top;
                    }
                }
                lastChunk = chunk;
            }
            if (lastChunk != null)
                lineRectangles.Add(new Rectangle(left, bottom, right, top));
            string str = sb.ToString();
            TextLines = str.Replace("\r\n", "\n").Split('\n');
            return str;

        }
        private bool SameLine(ExtendedTextChunk thisChunk, ExtendedTextChunk prevChunk)
        {
            //if (prevChunk.rectangle.Bottom - thisChunk.rectangle.Bottom < 0.5 * thisChunk.rectangle.Height)
            //    return true;
            //else
            //    return false;
            float maxHeight = Math.Max(prevChunk.rectangle.Height, thisChunk.rectangle.Height);
            if (Math.Abs(prevChunk.rectangle.Bottom - thisChunk.rectangle.Bottom) < 0.5 * maxHeight)
                return true;        // consistent with chunk comparison
            else
                return false;
        }
        public Rectangle[] GetLineRectangles()
        {
            return lineRectangles.ToArray();
        }
        public string[] GetTextLines()
        {
            int totalLength = 0;
            foreach (var line in TextLines) totalLength += line.Length;
            if (totalLength == 0)
                return new string[] { };
            else
                return TextLines;
        }

    }
}

