namespace ProjectBD.Model.SideModel
{
    public class Response
    {
        public bool status { get; set; }
        public object result { get; set; }
        public string message { get; set; }
        public double _total { get; set; }
        public double _page { get; set; }
        public double _limit { get; set; }
        public Response()
        {
            result = new object();
        }
    }
}
