using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            MiServicios.Service1Client oClient = new MiServicios.Service1Client();


          string res =  oClient.GetData(5,3);

            Console.WriteLine(res);



            MiServicios.CompositeType oData = new MiServicios.CompositeType();
            oData.BoolValue = true;

            var res2 = oClient.GetDataUsingDataContract(oData);

            Console.WriteLine(res2.StringValue);
        }
    }
}
