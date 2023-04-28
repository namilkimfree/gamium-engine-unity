using Gamium.Private;
using Gamium.Private.Debug;
using Gamium.Private.Object;
using Gamium.Private.Util;
using UnityEngine;

namespace Gamium
{
    public class ServerBuilder
    {
        public ServerBuilder SetStateHandler(IEventHandler eventHandler)
        {
            Assert.IsTrue(GamiumThread.IsMainThread(),
                $"ServerBuilder.SetStateHandler() must be called from main thread");

            _server.SetStateHandler(eventHandler);
            return this;
        }

        public ServerBuilder SetConfig(ServerConfig config)
        {
            Assert.IsTrue(GamiumThread.IsMainThread(), $"ServerBuilder.SetConfig() must be called from main thread");
            _server.SetConfig(config);
            return this;
        }

        public void StartServer()
        {
            Assert.IsTrue(GamiumThread.IsMainThread(), $"ServerBuilder.StartServer() must be called from main thread");

#if !USE_GAMIUM
            Debug.LogError("USE_GAMIUM Scripting Define Symbol is not set. Please set it in Edit > Project Settings > Player > Other Settings > Scripting Define Symbols");
            return;
#else
            var serverComponentGo = new GameObject("GamiumServer");
            ServerComponent.Behaviour _instance = serverComponentGo.AddComponent<ServerComponent.Behaviour>();
            serverComponentGo.AddComponent<TaskManager.Behaviour>();
            serverComponentGo.AddComponent<InputOverride.Behaviour>();
            {
                var eventSystemGo = new GameObject("GamiumEventSystem");
                eventSystemGo.transform.parent = serverComponentGo.transform;
                eventSystemGo.AddComponent<GamiumEventSystem.Behaviour>();
            }

            Visual.Setup(serverComponentGo);

            var types = Codebase.Setup();
            GamiumObjectRegistry.Setup(types);
            InputModule.Setup();

            ActionsHandler.Setup();
            InternalCommandHandler.Setup();

            _instance.StartServer(_server).ContinueWith(task =>
            {
                if (task.IsFaulted || task.IsCanceled || null != task.Exception)
                {
                    Gamium.Private.Util.Logger.Error(
                        $"GamiumServer Start failed. fault:{task.IsFaulted}, cancel:{task.IsCanceled}, exception:{task.Exception}");
                }
            });
#endif
        }

        internal Server _server = new Server();
    }
}
