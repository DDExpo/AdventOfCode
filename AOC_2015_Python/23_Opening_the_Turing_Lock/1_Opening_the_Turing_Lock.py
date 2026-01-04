from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    manual = [inst.strip('\n').replace(",", " ").split() for inst in file.readlines()]

    registers = {"a": 0, "b": 0}
    instructions = {"hlf": lambda x: x // 2, "tpl": lambda x: x * 3, "inc": lambda x: x + 1}

    answer: int = 0
    index:  int = 0
    
    while index < len(manual):
        inst = manual[index]
        if inst[0] == "jmp":
            index += int(inst[1])
        elif inst[0] == "jie" and registers[inst[1]] % 2 == 0:
            index += int(inst[2])
        elif inst[0] == "jio" and registers[inst[1]] == 1:
            index += int(inst[2])
        elif inst[0] in {"hlf", "tpl", "inc"}:
            registers[inst[1]] = instructions[inst[0]](registers[inst[1]])
            index += 1
        else:
            index += 1

    print(registers) 
