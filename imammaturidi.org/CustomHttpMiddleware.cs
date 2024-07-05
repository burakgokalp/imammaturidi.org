namespace imammaturidi.org
{
    public class CustomHttpMiddleware
    {
        private WebApplication _app;
        public CustomHttpMiddleware(WebApplication app) {  
            _app = app; 
        }
    }
}
