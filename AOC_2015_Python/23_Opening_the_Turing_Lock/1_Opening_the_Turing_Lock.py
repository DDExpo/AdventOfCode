import heapq
from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    SPELLS = {
        "magic_missile": {"cost": 53,  "damage": 4, "heal": 0},
        "drain":         {"cost": 73,  "damage": 2, "heal": 2},
        "shield":        {"cost": 113, "duration": 6, "effect": 7},
        "poison":        {"cost": 173, "duration": 6, "effect": 3},
        "recharge":      {"cost": 229, "duration": 5, "effect": 101},
    }
    answer          = float("inf")
    mana_spent: int = 0
    hero_hp:    int = 50
    hero_mana:  int = 500
    
    boss_stats:  list[str] = file.readlines()
    boss_hp:     int = int(boss_stats[0].split(":")[1].strip("\n"))
    boss_damage: int = int(boss_stats[1].split(":")[1].strip("\n"))

    pq = [(mana_spent, boss_hp, hero_mana, hero_hp, 0, 0, 0)]

    while pq:
        mana_spent, bossHP, mana, hp, shield, poison, recharge = heapq.heappop(pq)
        if mana_spent >= answer: continue

        if shield > 0: shield -= 1
        if poison > 0:
            bossHP -= SPELLS["poison"]["effect"]
            poison -= 1
        if recharge > 0:
            mana     += SPELLS["recharge"]["effect"]
            recharge -= 1
            
        if bossHP <= 0:
            answer = min(answer, mana_spent)
            continue    

        for spell, characteristics in SPELLS.items():
            newMana = mana - characteristics["cost"]
            if newMana < 0: continue

            spentMn     = mana_spent + characteristics["cost"]
            bHP         = bossHP
            newHP       = hp
            newShield   = shield
            newPoison   = poison
            newRecharge = recharge

            if spell in {"magic_missile", "drain"}:
                bHP   -= characteristics["damage"]
                newHP += characteristics["heal"]
            else:
                if spell == "shield":
                    if newShield > 0: continue
                    newShield = characteristics["duration"]
                elif spell == "poison":
                    if newPoison > 0: continue
                    newPoison = characteristics["duration"]
                elif spell == "recharge":
                    if newRecharge > 0: continue
                    newRecharge = characteristics["duration"]

            if newShield > 0: newShield -= 1
            if newPoison > 0:
                bHP       -= SPELLS["poison"]["effect"]
                newPoison -= 1
            if newRecharge > 0:
                newMana     += SPELLS["recharge"]["effect"]
                newRecharge -= 1

            if bHP <= 0:
                answer = min(answer, spentMn)
                continue
            
            newHP -= boss_damage - SPELLS["shield"]["effect"] if newShield > 0 else boss_damage
            if newHP > 0:
                heapq.heappush(pq, (spentMn, bHP, newMana, newHP, newShield, newPoison, newRecharge))
            
    print(answer)
