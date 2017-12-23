﻿using Plus.HabboHotel.Rooms;
using Plus.HabboHotel.Items;

namespace Plus.Communication.Packets.Incoming.Rooms.Furni
{
    class ThrowDiceEvent : IPacketEvent
    {
        public void Parse(HabboHotel.GameClients.GameClient session, ClientPacket packet)
        {
            Room room = session.GetHabbo().CurrentRoom;
            if (room == null)
                return;

            Item item = room.GetRoomItemHandler().GetItem(packet.PopInt());
            if (item == null)
                return;

            bool hasRights = false;
            if (room.CheckRights(session, false, true))
                hasRights = true;

            int request = packet.PopInt();

            item.Interactor.OnTrigger(session, item, request, hasRights);
        }
    }
}
