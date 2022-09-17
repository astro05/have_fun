def reverse_string_in_position(input_string):
    ns = ""
    rs = ""
    l = len(input_string)
    for i in input_string:
        l = l-1
        if i != " ":
            ns = i + ns

        if i == " " or l == 0:
            for j in ns:
                rs = rs + j
            if l != 0:
             rs = rs + " "
            ns = ""




    print(input_string)
    print(rs)
    print(len(input_string))
    print(len(rs))

reverse_string_in_position("Never Odd or Even") #reveN ddO ro nevE
reverse_string_in_position("abc def") #cba fed
reverse_string_in_position("aba") #aba
