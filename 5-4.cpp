
 //�������� ����� 3���-2
#include <iostream>
#include <vector>

int main() {
    setlocale(LC_ALL, "Russian");
    int N;
    std::cout << "������� ������ �������: ";
    std::cin >> N;

    std::vector<double> arr(N);

    std::cout << "������� �������� �������:\n";
    for (int i = 0; i < N; i++) {
        std::cin >> arr[i];
    }

    // 1) ��������� ������������ ��������� ������� � ��������� ��������
    double product_odd = 1.0;
    for (int i = 0; i < N; i += 2) {
        product_odd *= arr[i];
    }
    std::cout << "������������ ��������� ������� � ��������� ��������: " << product_odd << std::endl;

    // 2) ��������� ����� ��������� �������, ������������� ����� ������ � ��������� �������������� ����������
    
    double largest_negative = std::numeric_limits<double>::lowest(); // ������������� ����� ����� ������������� ������
    double smallest_negative = -std::numeric_limits<double>::max(); // ������������� �����, ��� ��� ��� ������������� �����
    int largest_neg_index = -1;
    int smallest_neg_index = -1;
    
    // ����� ������ �������� � ������ ���������� �������������� �����
   
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
    // ���� �� ������� ������������� ����� � �������
    if (largest_neg_index == -1 || smallest_neg_index == -1) {
        std::cout << "������������� ����� � ������� ���." << std::endl;
    }
    //���������� �����
    double sum = 0;
    int start_index = std::min(largest_neg_index, smallest_neg_index) + 1;
    int end_index = std::max(largest_neg_index, smallest_neg_index);
    for (int i = start_index; i < end_index; ++i) {
        sum += arr[i];
    }

    std::cout << "����� ��������� ����� ����: " << sum << std::endl;


    // ����� ������, ������ �� ���� ��� ��������, ������ ������� �� ��������� 1
    for (int i = 0; i < arr.size(); i++) {
        if (std::abs(arr[i]) <= 1) {
            arr.erase(arr.begin() + i);
            i--;
        }
    }
    // ���������� � ����� ������� �������� � ��������� �� ������
    int original_size = arr.size();
    for (int i = 0; i < N - original_size; i++) {
        arr.push_back(0);
    }

    // ����� ��������������� �������
    std::cout << "�������������� ������:\n";
    for (int i = 0; i < arr.size(); i++) {
        std::cout << arr[i] << " ";
    }
    std::cout << std::endl;

}