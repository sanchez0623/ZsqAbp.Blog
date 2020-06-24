using System;
using System.Collections.Generic;
using System.Text;

namespace ZsqAbp.Blog.HelloWorld.Impl
{
    public class HelloWorldService : ServiceBase, IHelloWorldService
    {
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
