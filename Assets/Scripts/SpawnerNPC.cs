using UnityEngine;
using UnityEngine.Pool;

public class SpawnerNPC : MonoBehaviour
{
    [SerializeField] private NPC _prefabNPC;
    [SerializeField] private Map _map;

    private ObjectPool<NPC> _poolNPC;

    private void Awake()
    {
        _poolNPC = new ObjectPool<NPC>(
            createFunc: () => Instantiate(_prefabNPC),
            actionOnGet: (npc) => ActionOnGet(npc),
            actionOnRelease: (npc) => ActionOnRelease(npc)
            );
    }

    public void GetNPC()
    {
        _poolNPC.Get();
    }

    public void ReturnNPC(NPC npc)
    {
        _poolNPC.Release(npc);
    }
    
    public void Return(NPC npc)
    {
          _poolNPC.Release(npc);
    }

    private void ActionOnGet(NPC npc)
    {
        npc.EndWent += ReturnNPC;

        npc.transform.position = _map.DefinePosition();

        npc.gameObject.SetActive(true);
    }

    private void ActionOnRelease(NPC npc)
    {
        npc.EndWent -= ReturnNPC;

        npc.gameObject.SetActive(false);
    }
}
