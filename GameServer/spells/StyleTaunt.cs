/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */
using System;
using DOL.AI.Brain;
using DOL.GS.Effects;

namespace DOL.GS.Spells
{
    /// <summary>
    /// Style taunt effect spell handler
    /// </summary>
    [SpellHandler("StyleTaunt")]
    public class StyleTaunt : SpellHandler
    {
        public override int CalculateSpellResistChance(GameLiving target)
        {
            return 0;
        }

        /// <summary>
        /// Determines wether this spell is compatible with given spell
        /// and therefore overwritable by better versions
        /// spells that are overwritable cannot stack
        /// </summary>
        /// <param name="compare"></param>
        /// <returns></returns>
        public override bool IsOverwritable(GameSpellEffect compare)
        {
            return false;
        }

        public override void OnDirectEffect(GameLiving target, double effectiveness)
        {
            if (target is GameNPC npc)
            {
                if (Caster.TempProperties.getProperty<object>(GameLiving.LAST_ATTACK_DATA, null) is AttackData ad)
                {
                    if (npc.Brain is IOldAggressiveBrain aggroBrain)
                    {
                        int aggro = Convert.ToInt32(ad.Damage * Spell.Value);
                        aggroBrain.AddToAggroList(Caster, aggro);
                    }
                }
            }
        }

        // constructor
        public StyleTaunt(GameLiving caster, Spell spell, SpellLine line) : base(caster, spell, line) { }
    }
}