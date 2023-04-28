using System.Threading.Tasks;
using Gamium.Private;
using UnityEngine;
using Logger = Gamium.Private.Util.Logger;

namespace Gamium
{
    public class ServerComponent
    {
        public class Behaviour : MonoBehaviour
        {
            private float logTime = 0;

            internal async Task StartServer(Server server)
            {
                DontDestroyOnLoad(gameObject);
                GameObjectInstance = gameObject;
                Logger.isVerbose = server._config.isVerbose;

                if (null == server) return;

                int startRet = await server.Start();
                if (0 != startRet)
                {
                    Logger.Error($"GamiumServer Start Failed: {startRet} {server.GetLastErrorMessage()}");
                }

                Logger.Verbose($"GamiumServer Version : {server.GetVersion()}");

                _server = server;
            }

            internal void Update()
            {
                if (null == _server) return;
                logTime += Time.deltaTime;

                int updateRet = _server.Update();
                if (0 != updateRet)
                {
                    Logger.Error(
                        $"GamiumServer Update Failed: {updateRet} {_server.GetLastErrorMessage()}");
                }

                if (10.0f <= logTime)
                {
                    Logger.Verbose($"GamiumServer Update");
                    logTime = 0;
                }
            }

            private void OnApplicationQuit()
            {
                if (null == _server) return;
                _server.Stop();
            }

            internal Server _server;
            internal static GameObject GameObjectInstance;
        }
    }
}
