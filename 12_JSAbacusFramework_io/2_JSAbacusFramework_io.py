import json
from pathlib import Path


def represents_int(s):
    try: 
        int(s)
    except ValueError:
        return False
    else:
        return True

with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    answ = 0
    storage_books = dict(json.load(file))

    for _, val in storage_books.items():

        val = str(val)
        to_delete = False
        stack = []
        min_open = 10000000
        red_parts = []

        for i, ch in enumerate(val):
            if ch in "{[":
                stack.append((i, ch))
            elif ch in "]}":
                ind, lch = stack.pop()
                if lch == "r" and stack[-1][1] == "{":
                    print("+")
                    red_parts.append((stack[-1][0], i))
                    stack.pop()

            if i+2 < len(val) and val[i] + val[i+1] + val[i+2] == "red":
                stack.append((0,"r"))
            print(stack)
        print(red_parts)
        break

        # new_str = ""
        
        # red_parts.append((len(val)-1, len(val)))
        # red_parts = [(0,0)] + red_parts

        # for i in range(len(red_parts)-1):
        #     new_str += val[red_parts[i][1]+1: red_parts[i+1][0]+1]

        # for vals in new_str.strip().split(","):
        #     for v in vals.split(":"):
        #         v = v.replace("[", "").replace("{", "").replace("]", "").replace("}", "").strip()
                
        #         if represents_int(v):
        #             answ += int(v)

    print(answ)
