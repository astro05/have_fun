# def max_pairwise_product(numbers):
#     number_max1 = max(numbers)
#     numbers.remove(number_max1)
#     number_max2 = max(numbers)
#     return number_max1 * number_max2

def max_pairwise_product(numbers):
    number = sorted(numbers)
    return number[-1] * number[-2]

if __name__ == '__main__' :
    input_no = int(input())
    
    lst = [int(x) for x in input().split()]

    print(max_pairwise_product(lst))
