using ProjectBD.Model.SideModel;

namespace ProjectBD.Helper
{
    public class PaginationHelper
    {
        public static Response Paginate<T>(List<T> source, int? page, int? limit)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            page = page <= 0 ? 1 : page;
            limit = limit <= 0 ? source.Count : limit;


            int startIndex = (page.Value - 1) * limit.Value;
            var paginatedData = source.Skip(startIndex).Take(limit.Value).ToList();

            var response = new Response
            {
                status = true,
                result = paginatedData,
                message = "Lấy dữ liệu thành công",
                _total = limit.Value == 0 ? 0 : (int)Math.Ceiling((double)source.Count / limit.Value),
                _page = page.Value,
                _limit = (int)limit
            };

            return response;
        }

        public static Response Paginate<T>(T source, string result)
        {
            var response = new Response
            {
                status = true,
                result = source,
                message = result,
                _total = 1,
                _page = 1,
                _limit = 1
            };

            return response;
        }
        public static Response Paginate<T>(IEnumerable<T> source)
        {
            var response = new Response
            {
                status = true,
                result = source,
                message = "Lấy dữ liệu thành công",
                _total = 1,
                _page = 1,
                _limit = source.Count()
            };

            return response;
        }
        public static Response Message(string result)
        {
            var response = new Response
            {
                status = false,
                result = 0,
                message = result,
                _total = 1,
                _page = 1,
                _limit = 1
            };

            return response;
        }
    }
}
