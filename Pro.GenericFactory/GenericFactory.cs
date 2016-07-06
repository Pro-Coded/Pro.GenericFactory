namespace Pro.GenericFactory
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    using Fasterflect;

    #endregion

    public static class GenericFactory
    {
        #region Static Fields

        /// <summary>
        ///     A cache of pre-registered ConstructorInvokers.
        /// </summary>
        private static readonly Dictionary<string, ConstructorInvoker> InvokerCache;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Creates the InvokerCache instance, which acts as a Singleton.
        /// </summary>
        static GenericFactory()
        {
            InvokerCache = new Dictionary<string, ConstructorInvoker>(StringComparer.Ordinal);
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Removes all ConstructorInvokers from the InvokerCache.
        /// </summary>
        public static void ClearRegistrations()
        {
            InvokerCache.Clear();
        }

        /// <summary>
        ///     Creates an object based upon the specified key that was used to Register the Type and Argument Types.
        ///     The Register method must have been called for this key, or an exception will be thrown.
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="id"></param>
        /// <param name="args"></param>
        /// <returns>An instance of the specified type.</returns>
        public static TType CreateInstance<TType>(string id, params object[] args) where TType : class
        {
            try { return (TType)InvokerCache[id](args); }

            catch (KeyNotFoundException)
            {
                throw new ArgumentException($"{id}' is not registered with the GenericFactory.");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Unable to create instance for '{id} / {typeof(TType)}'.", ex);
            }
        }

        /// <summary>
        ///     Check if a ConstructorInvoker has been Registered, with a specific 'id'.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>boolean</returns>
        public static bool IsRegistered(string id)
        {
            return InvokerCache.ContainsKey(id);
        }

        /// <summary>
        ///     Registers a ConstructorInvoker, cached and used to create the object when calling CreateInstance.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="argTypes">An array of Types, thfor paramaters</param>
        /// <returns>A boolean 'true' idf successful, otherwise, an exception is thrown</returns>
        public static bool Register<TType>(string id, Type[] argTypes) where TType : class
        {
            if (InvokerCache.ContainsKey(id)) { throw new ArgumentException($"'{id}' is already registered with the GenericFactory."); }

            var constructorInvoker = typeof(TType).DelegateForCreateInstance(argTypes);

            try
            {
                InvokerCache.Add(id, constructorInvoker);
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Unable to register '{id}'.", ex);
            }
        }

        /// <summary>
        ///     Removes a previously registered ConstructorInvoker, specified by a string 'id'.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A boolean 'true' if successful, otherwise, an exception is thrown.</returns>
        public static bool UnRegister(string id)
        {
            if (!InvokerCache.ContainsKey(id)) { throw new ArgumentException($"Unable to unregister '{id}', it is not registered with the GenericFactory."); }

            try
            {
                InvokerCache.Remove(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Unable to unregister Factory method for '{id}'.", ex);
            }
        }

        #endregion
    }
}