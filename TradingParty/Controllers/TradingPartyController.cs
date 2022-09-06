using Microsoft.AspNetCore.Mvc;
using System.Reactive;

namespace TradingParty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TradingPartyController : ControllerBase
    {
        BroadcastService broadcastService;

        public TradingPartyController(BroadcastService broadcastService)
        {
            this.broadcastService = broadcastService;
            this.broadcastService.Subscribe(SubscribedMethod);
            // this.broadcastService.Subscribe(SubscribedMethod2);
        }

        private void SubscribedMethod(int payload)
        {
            {
                Thread.Sleep(10000);
                System.Diagnostics.Debug.WriteLine(payload);
            }
        }   

        [HttpGet]       
        public IEnumerable<int> Get()
        {            
            return Enumerable.Range(1, 5);
        }


        [HttpGet]
        [Route("broadcast")]
        public void Broadcast()
        {
            Task.Run(() => this.broadcastService.Broadcast(1));
            Task.Run(() => this.broadcastService.Broadcast(2)).Wait();
           
        }
    }
}