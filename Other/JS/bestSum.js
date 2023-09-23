const bestSum = (target, nums, cache = {}) => {
  if (target in cache) return cache[target];
  if (target === 0) return [];
  if (target < 0) return null;

  let shortestCombination = null;

  for (const num of nums) {
    let result = bestSum(target - num, nums, cache);

    if (result !== null) {
      const combination = [...result, num];

      if (
        shortestCombination === null ||
        combination.length < shortestCombination.length
      ) {
        shortestCombination = combination;
      }
    }
  }

  cache[target] = shortestCombination;

  return shortestCombination;
};

console.log(bestSum(7, [5, 3, 4, 7]));
console.log(bestSum(8, [2, 3, 5]));
console.log(bestSum(8, [1, 4, 5]));
console.log(bestSum(100, [1, 2, 5, 25]));
