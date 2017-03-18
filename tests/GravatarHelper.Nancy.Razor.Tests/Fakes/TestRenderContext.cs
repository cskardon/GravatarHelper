using System;
using System.Collections.Generic;
using Nancy;
using Nancy.Localization;
using Nancy.ViewEngines;

namespace GravatarHelper.Nancy.Razor.Tests.Fakes
{
    public class TestRenderContext : IRenderContext
    {
        public TestRenderContext(NancyContext context)
        {
            Context = context;
        }

        public string ParsePath(string input)
        {
            throw new NotImplementedException();
        }

        public string HtmlEncode(string input)
        {
            throw new NotImplementedException();
        }

        public ViewLocationResult LocateView(string viewName, dynamic model)
        {
            throw new NotImplementedException();
        }

        public KeyValuePair<string, string> GetCsrfToken()
        {
            throw new NotImplementedException();
        }

        public NancyContext Context { get; }

        public IViewCache ViewCache
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ITextResource TextResource
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public dynamic TextResourceFinder
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}