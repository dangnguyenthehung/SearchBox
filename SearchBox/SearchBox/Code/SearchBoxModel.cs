using SearchBox.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchBox.Code
{
    public class SearchBoxModel
    {
        public ResultObj result = new ResultObj();
        public SearchBoxModel()
        {
            string name = "Nhà chính chủ ";
            string type = "cho thuê ";
            int district = 6;
            string city = "Hồ Chí Minh city";
            string content = "";

            ResultObj obj = new ResultObj();
            obj.Name = name;
            obj.Type = type;
            obj.District = district;
            obj.City = city;
            obj.Content = content;

            result = obj;
        }
    }
}
