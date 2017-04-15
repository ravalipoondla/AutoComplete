namespace AutoCompleteApplication
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Ninject;
    using Ninject.Syntax;
    using AutoCompleteFilter;


    /// <summary>
    /// NINJECT Dependency Resolver class
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver, IDisposable
    {
        /// <summary>
        /// kernel instance
        /// </summary>
        private IKernel kernel;
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyResolver" /> class
        /// </summary>
        public NinjectDependencyResolver() 
        {
            this.kernel = new StandardKernel();
            this.AddBindings();
        }

        /// <summary>
        /// Gets kernel object
        /// </summary>
        public IKernel Kernel
        {
            get { return this.kernel; }
        }
        /// <summary>
        /// Get Service method 
        /// </summary>
        /// <param name="serviceType">service type</param>
        /// <returns>returns object </returns>
        public object GetService(Type serviceType) 
        {
            return this.kernel.TryGet(serviceType);
        }
        /// <summary>
        /// Get Services method
        /// </summary>
        /// <param name="serviceType">service type</param>
        /// <returns>returns list of objects</returns>
        public IEnumerable<object> GetServices(Type serviceType) 
        {
            return this.kernel.GetAll(serviceType);
        }
        /// <summary>
        /// Binds object of type 'T'
        /// </summary>
        /// <typeparam name="T">type of object</typeparam>
        /// <returns>returns object</returns>
        public IBindingToSyntax<T> Bind<T>() 
        {
            return this.kernel.Bind<T>();
        }

        /// <summary>
        /// Dispose method
        /// </summary>

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);          
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        /// <param name="disposing">true or false</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.kernel != null)
                {
                    this.kernel.Dispose();
            }
            }
        }
        /// <summary>
        /// Add Bindings Method
        /// </summary>
        private void AddBindings()
        {
            this.Bind<IFilterService>().To<FileFilterService>();
        }
    }
}