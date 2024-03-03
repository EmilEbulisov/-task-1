
 //Эбулисов Эмиль 3ИСП-2

#include <iostream>
#include <vector>
#include <algorithm>

int main() {
    setlocale(LC_ALL, "Russian");
    int N;
    std::cout << "Введите размер массива: ";
    std::cin >> N;

    std::vector<int> arr(N);

    std::cout << "Введите элементы массива:\n";
    for (int i = 0; i < N; i++) {
        std::cin >> arr[i];
    }

    // 1) Найти минимальный по модулю элемент массива
    int min_abs_value = std::abs(arr[0]); // Инициализация минимального значения
    for (int i = 1; i < N; i++) {
        if (std::abs(arr[i]) < min_abs_value) {
            min_abs_value = std::abs(arr[i]);
        }
    }

    std::cout << "Минимальный по модулю элемент массива: " << min_abs_value << std::endl;

    // 2) Вычислить сумму модулей элементов массива, расположенных после первого равного нулю элемента
    int sum_after_zero = 0;
    bool zero_found = false;

    for (int i = 0; i < N; i++) {
        if (zero_found) {
            sum_after_zero += std::abs(arr[i]);
        }
        if (arr[i] == 0) {
            zero_found = true;
        }
    }

    std::cout << "Сумма модулей элементов после первого нулевого элемента: " << sum_after_zero << std::endl;


    // Преобразовать массив так, чтобы сначала располагались элементы, стоящие в четных позициях, а потом – стоящие в нечетных позициях
    std::sort(arr.begin(), arr.end(), [](int a, int b) {
        if (a % 2 == 0 && b % 2 != 0) {
            return true;
        }
        else if (a % 2 != 0 && b % 2 == 0) {
            return false;
        }
        else {
            return a < b;
        }
        });

    std::cout << "Результирующий массив:\n";
    for (int i = 0; i < N; i++) {
        std::cout << arr[i] << " ";
    }
    std::cout << std::endl;
}
