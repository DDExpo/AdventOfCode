package main

import (
	"aoc2024golang/tasks"
	"fmt"
	"path/filepath"
	"runtime"
)

func main() {
	_, filename, _, ok := runtime.Caller(0)
	if !ok {
		panic("runtime.Caller failed")
	}
	path := filepath.Dir(filename)

	fmt.Println("Day1")
	tasks.Day1(path)
}
