using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using D3Sharp.Core.Ingame.Universe;
using D3Sharp.Utils;
using System.Threading;
using System.Windows.Forms;

namespace D3Sharp.Net.Game
{
    public class ClientManager
    {
        int i = 0;


        protected static readonly Logger Logger = LogManager.CreateLogger();

        public static List<Universe> Universes = new List<Universe>();

        public static void OnConnect(object sender, ConnectionEventArgs e)
        {
            Logger.Trace("Game-Client connected: {0}", e.Connection.ToString());

            //D3Mighty.FormMusic _eDAE = new D3Mighty.FormMusic();
            //_eDAE.PlayerConnect();

            // atm, just creating a universe - though clients should be able to join existing ones.
            var universe = new Universe();
            Universes.Add(universe);

            var gameClient = new GameClient(e.Connection,universe);
            e.Connection.Client = gameClient;
        }

        
        public static void PlayerConnectD3GS()
        {
            for (int i = 0; i < 2; i++)//(int i = 0; i < 5; i++)
            {
                i++;
                Form1 pvpgn = new Form1();
                Thread backgroundThread = new Thread(new ThreadStart(pvpgn.PlayerConnect));
                backgroundThread.Start();
            }
        }
        

        public static void OnDisconnect(object sender, ConnectionEventArgs e)
        {
            Logger.Trace("Client disconnected: {0}", e.Connection.ToString());
            PlayerDisconnectD3GS();

            Universes.Remove(((GameClient) e.Connection.Client).Player.Universe);
        }

        public static void PlayerDisconnectD3GS()
        {
        for (int i = 0; i < 2; i++)//(int i = 0; i < 5; i++)
            {
                i++;
                Form1 pvpgn = new Form1();
                Thread backgroundThread = new Thread(new ThreadStart(pvpgn.PlayerDisconnect));
                backgroundThread.Start();
            }
        }
    }
}
