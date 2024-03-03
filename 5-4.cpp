
 //Эбулисов Эмиль 3ИСП-2
#include <iostream>
#include <vector>

int main() {
    setlocale(LC_ALL, "Russian");
    int N;
    std::cout << "Введите размер массива: ";
    std::cin >> N;

    std::vector<double> arr(N);

    std::cout << "Введите элементы массива:\n";
    for (int i = 0; i < N; i++) {
        std::cin >> arr[i];
    }

    // 1) Вычислить произведение элементов массива с нечетными номерами
    double product_odd = 1.0;
    for (int i = 0; i < N; i += 2) {
        product_odd *= arr[i];
    }
    std::cout << "Произведение элементов массива с нечетными номерами: " << product_odd << std::endl;

    // 2) Вычислить сумму элементов массива, расположенных между первым и последним отрицательными элементами
    
    double largest_negative = std::numeric_limits<double>::lowest(); // Инициализация самым малым отрицательным числом
    double smallest_negative = -std::numeric_limits<double>::max(); // Инициализация нулем, так как нет отрицательных чисел
    int largest_neg_index = -1;
    int smallest_neg_index = -1;
    
    // Поиск самого большого и самого маленького отрицательного числа
   
    for (int i = 0; i < N; ++i) {
        if (arr[i] < 0) {
            if (arr[i] > largest_negative) {
                largest_negative = arr[i];
                largest_neg_index = i;
            }
            if (arr[i] < smallest_negative) {
                smallest_negative = arr[i];
                smallest_neg_index = i;
            }
        }
    }
    // Если не найдено отрицательных чисел в массиве
    if (largest_neg_index == -1 || smallest_neg_index == -1) {
        std::cout << "Отрицательных чисел в массиве нет." << std::endl;
    }
    //нахождение суммы
    double sum = 0;
    int start_index = std::min(largest_neg_index, smallest_neg_index) + 1;
    int end_index = std::max(largest_neg_index, smallest_neg_index);
    for (int i = start_index; i < end_index; ++i) {
        sum += arr[i];
    }

    std::cout << "Сумма элементов между ними: " << sum << std::endl;


    // Сжать массив, удалив из него все элементы, модуль которых не превышает 1
    for (int i = 0; i < arr.size(); i++) {
        if (std::abs(arr[i]) <= 1) {
            arr.erase(arr.begin() + i);
            i--;
        }
    }
    // Освободить в конце массива элементы и заполнить их нулями
    int original_size = arr.size();
    for (int i = 0; i < N - original_size; i++) {
        arr.push_back(0);
    }

    // Вывод результирующего массива
    std::cout << "Результирующий массив:\n";
    for (int i = 0; i < arr.size(); i++) {
        std::cout << arr[i] << " ";
    }
    std::cout << std::endl;

}