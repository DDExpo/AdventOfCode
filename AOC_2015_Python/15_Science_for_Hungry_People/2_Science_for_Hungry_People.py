from pathlib import Path
from pprint import pprint


with open(Path(__file__).resolve().parent / "task_data", "r") as file:
    
    ingredients = {}
    answ = 0

    for line in file.readlines():
        name, properties = line.strip().split(":")
        ingredients[name] = {p.split()[0][:3]:int(p.split()[1]) for p in properties.split(",") if p.split()[1] != "0"}

    for a in range(1, 100):
        for b in range(1, 100):
            if a+b > 100: continue
            for c in range(1, 100):
                if a+b+c > 100: continue
                for d in range(1, 100):
                    if 100 - (a + b + c + d) == 0:
                        if (b+c)*8+(a+d)*3 == 500:
                            durab = a*5 + b*-1
                            flavo = a*-3 + c*5 + d*-2
                            textu = b*5 + c*-1
                            capas = d*2
                            
                            if any([v for v in [durab, flavo, textu, capas] if v < 0]): continue
                            
                            answ = max(answ, durab*flavo*textu*capas)            
    print(answ)
    pprint(ingredients)
