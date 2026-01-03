from pathlib import Path

answer = 0

with open(Path(__file__).resolve().parent / "task_data", "r") as file:
    
    for dimensions_l_w_h in file.readlines():
        l, w, h = map(int, dimensions_l_w_h.split("x"))        
        surf_1, surf_2, surf_3 = 2*l*w, 2*w*h, 2*h*l
        answer += surf_1 + surf_2 + surf_3 + min(surf_1, surf_2, surf_3)//2

print(answer)