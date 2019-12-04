using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface myAagendaIService
{

    [OperationContract]

    int NuevoContacto(myAgenda agenda);


    [OperationContract]

    int EditarContacto(myAgenda agenda);

    [OperationContract]

    int EliminarContacto(int IdContacto);
    [OperationContract]

    int BuscarContacto(int IdContacto);
    [OperationContract]

    List<myAgenda> mostrarContactos();
}




[DataContract]
public class myAgenda
{
    int Id;
    int EstadoId;
    int IdSolicitud;
    int ProductoId;

    [DataMember]
    public int id
    {
        get { return Id; }
        set { Id = value; }
    }
    [DataMember]
    public int estadoId
    {
        get { return EstadoId; }
        set { EstadoId = value; }
    }
    [DataMember]
    public int idSolicitud
    {
        get { return IdSolicitud; }
        set { IdSolicitud = value; }
    }

    [DataMember]
    public int productoId
    {
        get { return ProductoId; }
        set { ProductoId = value; }
    }

}


