using Microsoft.AspNet.SignalR;
using MoveShapeDemo.Models;

namespace MoveShapeDemo.Hubs
{
    public class MoveShapeHub : Hub
    {
        public void UpdateModel(ShapeModel clientModel)
        {
            clientModel.LastUpdatedBy = Context.ConnectionId;
            Clients.AllExcept(clientModel.LastUpdatedBy).updateShape(clientModel);
        }
    }
}