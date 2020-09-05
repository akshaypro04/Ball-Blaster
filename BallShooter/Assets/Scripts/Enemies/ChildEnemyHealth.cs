using BallBlast.Comman.Destoy;
using BallBlast.Enemies.ControllerChild;

namespace BallBlast.Enemies.HealthChild
{
    public class ChildEnemyHealth : Destruable
    {
        EnemyChild m_enemy;
        EnemyChild enemy
        {
            get
            {
                if (m_enemy == null)
                    m_enemy = GetComponent<EnemyChild>();
                return m_enemy;
            }
        }



        public override void DamageTake(int amount)
        {
            base.DamageTake(amount);
        }

        public override void die()
        {
            base.die();
        }
    }
}

