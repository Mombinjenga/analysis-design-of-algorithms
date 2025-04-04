#include <iostream>
#include <chrono>

using namespace std;
using namespace std::chrono;

void fibonacci(int n) {
    long long a = 0, b = 1, next;
    cout << "Fibonacci Sequence: " << a << " " << b << " ";

    for (int i = 2; i < n; i++) {
        next = a + b;
        cout << next << " ";
        a = b;
        b = next;
    }
    cout << endl;
}

int main() {
    int num;
    cout << "Enter number of terms: ";
    cin >> num;

    auto start = high_resolution_clock::now(); 

    fibonacci(num);
    
    auto stop = high_resolution_clock::now(); 
    auto duration = duration_cast<microseconds>(stop - start);

    cout << "Execution Time: " << duration.count() << " microseconds" << endl;

    return 0;
}