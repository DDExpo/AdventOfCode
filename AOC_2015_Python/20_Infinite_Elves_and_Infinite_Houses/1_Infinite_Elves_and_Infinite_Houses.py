from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    target_presents_count = int(file.read().strip()[0:-2])

    
