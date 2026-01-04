import math
from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    target_presents_count = int(file.read().strip())

    n: int = target_presents_count // 5
    while True:
        divisors = set()
        for i in range(1, int(math.isqrt(n)) + 1):
            if n % i == 0:
                divN = n // i
                if divN*50 >= n:
                    divisors.add(divN)
                if i*50 >= n:
                    divisors.add(i)

        total = sum(divisors) * 11
        if total >= target_presents_count:
            print(n)
            break
        n += 1