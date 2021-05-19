using UnityEngine;
using Mirror;


// Custom NetworkManager that simply assigns the correct racket positions when
// spawning players. The built in RoundRobin spawn method wouldn't work after
// someone reconnects (both players would be on the same side).
[AddComponentMenu("")]
public class Network : NetworkManager
{
    public bool EndGame = false;
    public bool WinGame = false;

    public Transform leftRacketSpawn;
    public Transform rightRacketSpawn;
    GameObject player;

    Transform start;

    public Transform ScreenSpawn;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        // add player at correct spawn position
        start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
        player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);
    }

    public void Update()
    {
        if (EndGame == true)
        {
            EndGame = false;

            GameObject endScreen = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Canvas"), ScreenSpawn.position, ScreenSpawn.rotation);

            NetworkServer.Spawn(endScreen);
        }

        if (WinGame == true)
        {
            WinGame = false;

            GameObject endScreen = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Canvas2"), ScreenSpawn.position, ScreenSpawn.rotation);

            NetworkServer.Spawn(endScreen);
        }
    }

    public void killNetwork()
    {
        NetworkManager.Shutdown();
    }
}