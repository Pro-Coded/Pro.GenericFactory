# Pro.GenericFactory

A utility project to support fast class instantiation, using cached Delegate (ConstructorInvoker) methods, rather than Activator.CreateInstance or Expression Trees.

A Test project is included to verify class instantiation including multiple constructors, inheritance, etc.

GenericFactory is especially suited to systems architected using DDD, CQRS, CQRS+ES approaches, where many thousands of objects are instantiated.

A partner project, Pro.FastBus, will be released shortly, which can be used in conjunction with GenericFactory for Command dispatching, and Aggregate instance instantiation.

#Usage

Step 1. 

Register the class to be instantiated, using the generic Register method specifying the Type, and supplying a string id, and array of Types for any paramaters. Examples are listed below:

    GenericFactory.Register<EntityNoConstructor>("EntityNoConstructorKey", new Type[] { });
    GenericFactory.Register<EntitySingleConstructor>("EntitySingleConstructorKey", new[] { typeof(int) });
    
    GenericFactory.Register<EntityDoubleConstructor>("EntityDoubleConstructorKey1", new[] { typeof(int) });
    GenericFactory.Register<EntityDoubleConstructor>("EntityDoubleConstructorKey2", new[] { typeof(string) });
    
    GenericFactory.Register<EntityPerformanceTest>("EntityPerformanceTestKey", new[] { typeof(int), typeof(List<int>) });


Step 2. 

Instantiate an instance of a class using the generic CreateInstance method, specifying the Type, and supplying a string id, and any params.

    var instance = GenericFactory.CreateInstance<EntityPerformanceTest>("EntityPerformanceTestKey", 1, list);
    
    var instance = GenericFactory.CreateInstance<TAggregate>(aggregateTypeName, uid);

The project uses Fasterflect to create the ConstructorInvoker:
http://fasterflect.codeplex.com

The ConstructorInvoker is then cached in a static dictionary, and accessed via a string key that is matched using StringComparer.Ordinal; testing has shown this to be more performant than using Fasterflects internal caching.

#Performance

Basic performance tests are included which can be used to compare time to instantiate x number of classes, against using 'new' of a concrete type.

Samples results, running the performance tests on an Azure VM (2 Core, 7 GB, D Servies V2).

GenericFactory

10,000 instantiations 0.0007806 seconds
1,000,000 instantiations 0.0827468 seconds

Concrete New

10,000 instantiations 0.0000559 seconds
1,000,000 instantiations 0.0121796 seconds


Suggestions for improvement always welcome!

David Paul McQuiggin
Pro-Coded




 
 
 
