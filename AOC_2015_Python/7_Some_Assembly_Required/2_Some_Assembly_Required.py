import operator
from collections import defaultdict
from pathlib import Path


def search_deep(key: str, operation: list[list[str]]):

    if key.isdigit():
        return int(key)

    if (key) in known_vals:
        return known_vals[key]

    for oprt in operation:
        if len(oprt) <= 1:
            answ = search_deep(oprt[0], operations[oprt[0]])
        elif len(oprt) == 2:
            answ = bitwise_operations[oprt[0]](search_deep(oprt[1], operations[oprt[1]]))
        else:
            left_operand, bitwise_oprt, right_operand = oprt[0], oprt[1], oprt[2]
            answ = bitwise_operations[bitwise_oprt](search_deep(left_operand, operations[left_operand]), search_deep(right_operand, operations[right_operand]))

    known_vals[key] = answ
    return answ

with open(Path(__file__).resolve().parent / "task_data", "r") as file:
    
    bitwise_operations = {"OR": operator.or_, "AND": operator.and_, "RSHIFT": operator.rshift, "LSHIFT": operator.lshift, "NOT": operator.invert}
    
    known_vals = {}
    operations: dict[str, list[list[str]]] = defaultdict(list)

    for operation in file.readlines():
        values: list[str] = operation.strip().split()
        operations[values[-1]].append(values[:-2])
    operations["b"] = [["16076"]]
    print(search_deep("a", operations["a"]))
