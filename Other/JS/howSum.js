const howSum = (target, nums, cache = {}) => {
  if (target in cache) return cache[target];
  if (target === 0) return [];
  if (target < 0) return null;

  for (let num of nums) {
    const result = howSum(target - num, nums, cache);

    if (result !== null) {
      cache[target] = [...result, num];

      return cache[target];
    }
  }

  cache[target] = null;
  return null;
};

console.log(howSum(7, [2, 3]));
console.log(howSum(7, [5, 3, 4, 7]));
console.log(howSum(7, [2, 4]));
console.log(howSum(8, [2, 3, 5]));
console.log(howSum(300, [7, 14]));
