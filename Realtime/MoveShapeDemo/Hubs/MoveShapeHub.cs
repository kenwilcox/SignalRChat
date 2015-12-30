using Microsoft.AspNet.SignalR;
using MoveShapeDemo.Classes;
using MoveShapeDemo.Models;

namespace MoveShapeDemo.Hubs
{
    public class MoveShapeHub : Hub
    {
        private Broadcaster _broadcaster;

        public MoveShapeHub(): this(Broadcaster.Instance){}

        public MoveShapeHub(Broadcaster broadcaster)
        {
            _broadcaster = broadcaster;
        }

        public void UpdateModel(ShapeModel clientModel)
        {
            clientModel.LastUpdatedBy = Context.ConnectionId;
            _broadcaster.UpdateShape(clientModel);
        }

        public void GetMyId()
        {
            var id = Context.ConnectionId.Replace("-", "");
            Clients.Caller.updateMyId(id);
        }
    }
}