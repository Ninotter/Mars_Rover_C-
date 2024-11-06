using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MissionControl.Server
{
    internal class ClientManager
    {
        // 1. Instance statique privée
        private static ClientManager _instance;

        // 2. Objet verrou pour la synchronisation de l'accès au singleton (thread-safe)
        private static readonly object _lock = new object();

        // 3. Liste des clients (juste pour l'exemple)
        List<TcpClient> _clients = new List<TcpClient>();

        public List<TcpClient> Clients => _clients;

        // 4. Constructeur privé pour empêcher l'instanciation directe
        private ClientManager()
        {
            _clients = new List<TcpClient>();
        }

        // 5. Propriété statique publique pour accéder à l'instance
        public static ClientManager Instance
        {
            get
            {
                // Utilisation du verrou pour éviter les problèmes d'accès concurrent
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ClientManager();
                    }
                    return _instance;
                }
            }
        }

        // Méthode pour ajouter un client
        public void AddClient(TcpClient client)
        {
            _clients.Add(client);
        }
    }
}
