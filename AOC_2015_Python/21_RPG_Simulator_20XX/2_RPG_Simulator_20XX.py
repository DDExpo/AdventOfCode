from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    # Cost Damage Defense
    weapons = {
        "dagger":     (8, 4, 0),
        "shortsword": (10, 5, 0),
        "warhammer":  (25, 6, 0),
        "longsword":  (40, 7, 0),
        "greataxe":   (74, 8, 0),
    }
    armors = {
        "leather":    (13, 0, 1),
        "chainmail":  (31, 0, 2),
        "splintmail": (53, 0, 3),
        "bandedmail": (75, 0, 4),
        "platemail":  (102, 0, 5),
    }
    rings = [
        (25, 1, 0), (20, 0, 1),
        (40, 0, 2), (50, 2, 0),
        (80, 0, 3), (100, 3, 0),
    ]
    answer:  int = -1
    hero_hp: int = 100
    
    boss_stats  = file.readlines()
    boss_hp     = int(boss_stats[0].split()[2].strip("\n"))
    boss_damage = int(boss_stats[1].split()[1].strip("\n"))
    boss_armor  = int(boss_stats[2].split()[1].strip("\n"))
    
    def simulateBossFightLose(bossHP: int, heroHP: int, heroDamage: int, heroDefense: int, goldSpent: int) -> int:
        while bossHP > 0:
            bossHP -= max(1, max(heroDamage,  boss_armor)  - min(boss_armor,  heroDamage))
            heroHP -= max(1, max(heroDefense, boss_damage) - min(boss_damage, heroDefense))
            if heroHP <= 0:
                return max(answer, goldSpent)
        return answer
    
    for _, (cost, damage, _) in weapons.items():
        cur_gold_spent: int = cost

        for _, (armor_cost, _, defense) in armors.items():
            cur_gold_spent += armor_cost

            for rings_taken in range(3):
                if rings_taken == 0:
                    answer = simulateBossFightLose(boss_hp, hero_hp, damage, defense, cur_gold_spent)
                    
                if rings_taken == 1:
                    for ring_cost, ring_damage, ring_defense in rings:
                        answer = simulateBossFightLose(boss_hp, hero_hp, damage+ring_damage, defense+ring_defense, cur_gold_spent + ring_cost)

                if rings_taken == 2:
                    for i in range(6):
                        for ii in range(i+1, 6):
                            answer = simulateBossFightLose(
                                boss_hp, hero_hp, damage+rings[i][1]+rings[ii][1], defense+rings[i][2]+rings[ii][2],
                                cur_gold_spent + rings[i][0] + rings[ii][0]
                            )
            cur_gold_spent -= armor_cost

    print(answer)
