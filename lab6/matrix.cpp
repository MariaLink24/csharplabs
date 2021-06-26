class Matrix
{
	int n = 0;	
	double* A;	

				
public: Matrix(int n)
{	
	this->n = n;
	A = new double[n];
	for (int i = 0; i < n; i++)
		A[i] = (n + 1) - i;
}
	
public: Matrix(int n, double* input_array)
{	
	this->n = n;
	
	A = new double[n];
	
	for (int i = 0; i < n; i++)
		A[i] = input_array[i];
}

public: Matrix(const Matrix& other)
{	
	n = other.n;
	
	A = new double[n];
	
	for (int i = 0; i < n; i++)
		A[i] = other.A[i];
}
		
public: ~Matrix()
{	
	delete A;
}
public: Matrix& operator=(const Matrix &other)
{	
	this->n = other.n;
	
	A = new double[n];
	
	for (int i = 0; i < n; i++)
		A[i] = other.A[i];
}
public: double* Solve(double right[], double* answer = nullptr)
{	
	double* x = new double[n];
	x[0] = 1.0 / A[0];
	double* y = new double[n];
	y[0] = x[0];
	
	for (int k = 1; k <= n - 1; k++)
	{   
		double Fk = 0;
		for (int i = 0; i < k; i++)
			Fk += A[k - i] * x[i];
		
		double Gk = 0;
		for (int i = 0; i < k; i++)
			Gk += A[i + 1] * y[i];
		
		double rk = 1.0 / (1.0 - Fk * Gk);
		
		double sk = -rk * Fk;
		
		double tk = -rk * Gk;
		
		double* x_old = new double[k];
		for (int i = 0; i < k; i++)
			x_old[i] = x[i];
		
		double* y_old = new double[k];
		for (int i = 0; i < k; i++)
			y_old[i] = y[i];
		
		x[0] = x_old[0] * rk + 0 * sk;
		for (int i = 1; i < k; i++)
			x[i] = x_old[i] * rk + y_old[i - 1] * sk;
		x[k] = 0 * rk + y_old[k - 1] * sk;
		
		y[0] = x_old[0] * tk + 0 * rk;
		for (int i = 1; i < k; i++)
			y[i] = x_old[i] * tk + y_old[i - 1] * rk;
		y[k] = 0 * tk + y_old[k - 1] * rk;
		
		delete x_old; delete y_old;
	}

 
	double** matrix_a = new double*[n];
	double** matrix_b = new double*[n];
	double** matrix_c = new double*[n];
	double** matrix_d = new double*[n];
	for (int i = 0; i < n; i++)
	{
		matrix_a[i] = new double[n];
		matrix_b[i] = new double[n];
		matrix_c[i] = new double[n];
		matrix_d[i] = new double[n];
	}
	
	for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
		{
			matrix_a[i][j] = (i >= j) ? x[i - j] : 0;
			matrix_b[i][j] = (j >= i) ? y[n - 1 - j + i] : 0;
			matrix_c[i][j] = (i > j) ? y[i - 1 - j] : 0;
			matrix_d[i][j] = (j > i) ? x[n - 1 - j + 1 + i] : 0;
		}
	
	double** matrix_ab = new double*[n];
	double** matrix_cd = new double*[n];
	for (int i = 0; i < n; i++)
	{
		matrix_ab[i] = new double[n];
		matrix_cd[i] = new double[n];
	}
	
	for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
		{
			double sum_ab = 0;
			double sum_cd = 0;
			for (int k = 0; k < n; k++)
			{
				sum_ab += matrix_a[i][k] * matrix_b[k][j];
				sum_cd += matrix_c[i][k] * matrix_d[k][j];
			}
			matrix_ab[i][j] = sum_ab;
			matrix_cd[i][j] = sum_cd;
		}
	
	double** matrix_res = new double*[n];
	for (int i = 0; i < n; i++)
		matrix_res[i] = new double[n];

	for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
			matrix_res[i][j] = (1.0 / x[0]) * (matrix_ab[i][j] - matrix_cd[i][j]);

	if (answer == nullptr)  answer = new double[n];
	for (int i = 0; i < n; i++)
	{
		answer[i] = 0;
		for (int j = 0; j < n; j++)
			answer[i] += matrix_res[i][j] * right[j];
	}

	delete[] matrix_a;
	delete[] matrix_b;
	delete[] matrix_c;
	delete[] matrix_d;
	delete[] matrix_ab;
	delete[] matrix_cd;
	delete[] matrix_res;

	return answer;
}
};

#include <iostream>
#include <cstdio>
#include <ctime>

using namespace std;

extern "C" __declspec(dllexport) int Version()
{
	return 5;
}

extern "C" __declspec(dllexport) double FirstMethod_C(int n, int k)
	double duration = 0; clock_t start = clock();
	Matrix matrix = Matrix(n);
	double* right = new double[n];
	for (int i = 0; i < n; i++)
		right[i] = (i + 1) * 10;
	
	for (int i = 0; i < k; i++)
		matrix.Solve(right);
	duration = (clock() - start) / (double)CLOCKS_PER_SEC;
	delete right;
	return duration;
}

extern "C" __declspec(dllexport) void SecondMethod_C(int n, double matrix_array[], double right_array[], double* answer_array)
{	
	Matrix matrix = Matrix(n, matrix_array);
	matrix.Solve(right_array, answer_array);
}

int main()
{
	int version = Version();

	double time = FirstMethod_C(30, 1);

	double* matrix_array = new double[3]{ 4, 3, 2 };
	double* right_array = new double[3]{ 10, 20, 30 };
	double* answer_array = new double[3];

	SecondMethod_C(3, matrix_array, right_array, answer_array);

	return 0;
}