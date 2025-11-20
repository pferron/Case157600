using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceTestManager.Models
{
    public enum ModifierType
    {
        TestSet,
        Destination,
        File,
        ExecutedTest
    }
    public static class ModifierFactory
    {
        /// <summary>
        /// Create a editor model based on <see cref="ModifierType"/>
        /// </summary>
        /// <param name="modifierType">The type of Modifier requested</param>
        /// <param name="id">The id of the item requested</param>
        /// <returns></returns>
        public static IModifiable GetModifyModel(ModifierType modifierType, int id, User user)
        {
            switch (modifierType)
            {
                case ModifierType.TestSet:
                    return new TestSetModifier(id, user);
                case ModifierType.Destination:
                    return new DestinationModifier(id, user);
                case ModifierType.File:
                    return new FileModifier(id);
                default:
                    throw new ArgumentOutOfRangeException("editType");
            }
        }


        /// <summary>
        /// Create a editor model with a guid.
        /// </summary>
        /// <param name="editType">The type of edit requested</param>
        /// <param name="id">the guid id of the item to edit</param>
        /// <returns></returns>
        public static IModifiable GetModifyModel(ModifierType editType, Guid id)
        {
            switch(editType)
            {
                case ModifierType.File:
                    return new FileModifier(id);
                default:
                    throw new ArgumentOutOfRangeException("editType");
            }
        }

        /// <summary>
        /// Get a <seealso cref="IRemovable"/> object
        /// </summary>
        /// <param name="modifierType">The modifier type</param>
        /// <param name="id">the guid id of the object</param>
        /// <returns>a new removable object</returns>
        public static IRemovable GetRemovable(ModifierType modifierType, Guid id)
        {
            switch (modifierType)
            {
                case ModifierType.File:
                    return new FileModifier(id);
                case ModifierType.ExecutedTest:
                    return new ExecutedTestModifier(id);
                default:
                    throw new ArgumentException("modifierType");
            }
        }

        /// <summary>
        /// Get a <seealso cref="IRemovable"/> object
        /// </summary>
        /// <param name="modifierType">The modifier type</param>
        /// <param name="id">the int id of the object</param>
        /// <returns>a new removable object</returns>
        public static IRemovable GetRemovable(ModifierType modifierType, int id, User user)
        {
            switch (modifierType)
            {
                case ModifierType.TestSet:
                    return new TestSetModifier(id, user);
                case ModifierType.Destination:
                    return new DestinationModifier(id, user);
                default:
                    throw new ArgumentOutOfRangeException("modifierType");
            }
        }

    }
}