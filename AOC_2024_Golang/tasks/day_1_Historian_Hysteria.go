package tasks

import (
	"bufio"
	"fmt"
	"os"
	"sort"
	"time"
)

func Day1(path string) {
	left, right, err := readPairs(path + "/inputs/day_1.txt")
	if err != nil {
		fmt.Println("Error:", err)
		return
	}

	part1 := func() int {
		sort.Ints(left)
		sort.Ints(right)

		total := 0
		for i := range left {
			a := left[i]
			b := right[i]
			if a > b {
				total += a - b
			} else {
				total += b - a
			}
		}
		return total
	}

	start1 := time.Now()
	answer1 := part1()
	fmt.Printf("Time:\033[32m %.7f\033[0m  \033[33mPart 1: %v\033[0m\n", time.Since(start1).Seconds(), answer1)

	start2 := time.Now()
	answer2 := 0
	fmt.Printf("Time:\033[32m %.7f\033[0m  \033[31mPart 2: %v\033[0m\n", time.Since(start2).Seconds(), answer2)
}

func readPairs(filename string) ([]int, []int, error) {
	file, err := os.Open(filename)
	if err != nil {
		return nil, nil, err
	}
	defer file.Close()

	var left, right []int
	scanner := bufio.NewScanner(file)

	for scanner.Scan() {
		var a, b int
		_, err := fmt.Sscan(scanner.Text(), &a, &b)
		if err == nil {
			left = append(left, a)
			right = append(right, b)
		}
	}

	return left, right, scanner.Err()
}
