using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using D3Sharp.Core.Ingame.Universe;
using D3Sharp.Utils;

namespace D3Sharp.Net.Game
{
    public class ClientManager
    {
        protected static readonly Logger Logger = LogManager.CreateLogger();

        public static List<Universe> Universes = new List<Universe>();

        public static void OnConnect(object sender, ConnectionEventArgs e)
        {
            Form1 pvpgn = new Form1();
            Logger.Trace("Game-Client connected: {0}", e.Connection.ToString());
            pvpgn.richTextBox1.Text += "[D3GS] A Player connected. \n\f";

            // atm, just creating a universe - though clients should be able to join existing ones.
            var universe = new Universe();
            Universes.Add(universe);

            var gameClient = new GameClient(e.Connection,universe);
            e.Connection.Client = gameClient;
        }

        public static void OnDisconnect(object sender, ConnectionEventArgs e)
        {
            Form1 pvpgn = new Form1();
            Logger.Trace("Client disconnected: {0}", e.Connection.ToString());
            pvpgn.richTextBox1.Text += "[D3GS] A Player disconnected. \n\f";

            Universes.Remove(((GameClient) e.Connection.Client).Player.Universe);
        }
    }
}
