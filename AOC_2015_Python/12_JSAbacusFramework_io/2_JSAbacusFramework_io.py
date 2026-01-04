import json
from pathlib import Path

with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    def walk(x):
        if isinstance(x, int):
            return x
        if isinstance(x, list):
            return sum(walk(i) for i in x)
        if isinstance(x, dict):
            if "red" in x.values():
                return 0
            return sum(walk(v) for v in x.values())
        return 0

    data = json.loads(file.read())
    print(walk(data))

