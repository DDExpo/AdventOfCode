from collections import defaultdict
from pathlib import Path

with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    possible_replacements = defaultdict(list)
    medicine_molecule     = ""
    answ = set()
    
    for line in file.readlines():
        line = line.strip()
        
        if not line: continue
        
        if 0 < len(line) < 50:
            molecules = line.split("=>")
            possible_replacements[molecules[0].strip()].append(molecules[1].strip())
        else:
            medicine_molecule = line.strip()
    
    
    for key, values in possible_replacements.items():
        
        index = 0
        mol_to_replace = medicine_molecule.find(key, index)
        
        while mol_to_replace != -1:
            
            for val in values:
                answ.add(medicine_molecule[:mol_to_replace]+val+medicine_molecule[mol_to_replace+len(key):])
            index = mol_to_replace
            mol_to_replace = medicine_molecule.find(key, index+len(key))

    print(len(answ))
