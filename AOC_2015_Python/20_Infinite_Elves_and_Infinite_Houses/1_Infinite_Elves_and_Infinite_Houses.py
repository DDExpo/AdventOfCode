import math
from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    target_presents_count = int(file.read().strip())

    n: int = target_presents_count // 5
    while True:
        divisors = set()
        for i in range(1, int(math.isqrt(n)) + 1):
            if n % i == 0:
                divisors.add(i)
                divisors.add(n // i)
        total = sum(divisors) * 10
        if total >= target_presents_count:
            print(n)
            break
        n += 1
