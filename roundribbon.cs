
using MCVCore.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoundRibbonCore.Enities
{
    public class Conversations
    {
        [Key]
        public long ConversationID { get; set; }
        public long AgentID { get; set; }
        public string ConversationName { get; set; }
        public void Assgin_ConversationToAgent(long AgentID)
        {
            this.AgentID = AgentID;
        }
    }
    public class Agents
    {
        [Key]
        public long AgentID { get; set; }
        public string AgentName { get; set; }
        public bool mark { get; set; }
    }
    public class MainPage
    {
        public bool ApplyRoundRibbon(List<Agents> Agents, Conversations Conversation)
        {
            try
            {

                var oneAgent = Agents.Where(t => t.mark == false).FirstOrDefault();
                if(oneAgent!=null)
                {
                    Conversation.Assgin_ConversationToAgent(oneAgent.AgentID);
                    oneAgent.mark = true;
                    // DB.Agents.Update(oneAgent);
                    // DB.Conversations.Update(Conversation);
                    // DB.SaveChanges();
                    return true;
                }
                else if(Agents.Count>0)
                {
                    Conversation.Assgin_ConversationToAgent(Agents[0].AgentID);
                    // DB.Conversations.Update(Conversation);
                    for (int i = 1;i< Agents.Count;i++)
                    {
                        Agents[i].mark = false;
                        //DB.Agents.Update(agent);
                    }
                    // DB.SaveChanges();
                }

            }
            catch(Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}
