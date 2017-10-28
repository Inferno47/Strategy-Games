using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/*
 * Connection Client : MsgType.Connect OK
 * Add New Player : MsgType.AddPlayer
 * List NetworkHash128 : MsgType.Highest + 0
 * Ressource : MsgType.Highest + 1
 * Add/Delete Building : MsgType.Highest + 2
 * Add/Delete Unit : MsgType.Highest + 3
 * Move Unit : MsgType.Highest + 4
 * Syncronisation : MsgType.Highest + 5
 * Disconnect Player : MsgType.RemovePlayer
 * Disconnect Client : MsgType.Disconnect OK
 */

public class MessageServer : MessageBase
{
    public string Command;
    public string info;
}

public class MessageIdObject : MessageBase //msgServer + 0;
{
    public NetworkHash128 TypeId;
    public string info;
}

/*public class MessageListIdObject : MessageBase //msgServer + 0;
{
    public List<NetworkHash128> Command;
    public string info;
}*/

public class MessageRessource : MessageBase //msgServer + 1;
{
    public int Metal;
    public int Cristal;
    public int Gaz;
}

public class MessageUnit : MessageBase //msgServer + 2 or + 3;
{
    public Transform Position;
    public int IdUnit;
}

public class MessageHandler : MonoBehaviour {

    protected short msgServer = MsgType.Highest + 1;
    
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    /*public MessageBase ListId(List<NetworkHash128> typeIdList) {
        MessageListIdObject msg = new MessageListIdObject();
        msg.Command = typeIdList;
        msg.info = "typeId";
        return msg;
    }*/

    public List<MessageBase> ListId(List<NetworkHash128> typeIdList) {
        List<MessageBase> listMsg = new List<MessageBase>();

        foreach (NetworkHash128 typeId in typeIdList) {
            MessageIdObject msg = new MessageIdObject()
            {
                TypeId = typeId,
                info = "typeId"
            };
            listMsg.Add(msg);
        }
        return listMsg;
    }

    public MessageBase Resource(int metal, int cristal, int gaz) {
        MessageRessource msg = new MessageRessource
        {
            Metal = metal,
            Cristal = cristal,
            Gaz = gaz
        };
        return msg;
    }

    public MessageBase Unit(Transform position, int idUnit) {
        MessageUnit msg = new MessageUnit
        {
            Position = position,
            IdUnit = idUnit
        };
        return msg;
    }
}
