using SPGD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPGD.DAL
{
    public class AgentRepository: GenericRepository<Agent>
    {
        public AgentRepository(H15_PROJET_E09Entities1 context) : base(context) { }

        public IEnumerable<Agent> GetAgents()
        {
            IEnumerable<Agent> agents;
            agents = Get();
            return agents;
        }
        public Agent GetAgentByID(int? id)
        {
            return GetByID(id);
        }
        public void InsertAgent(Agent agent)
        {
            Insert(agent);
        }
        public void UpdateAgent(Agent agent)
        {
            Update(agent);
        }
        public void DeleteAgent(int id)
        {
            Delete(id);
        }
    }
}