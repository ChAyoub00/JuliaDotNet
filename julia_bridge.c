#include <stdio.h>
#include <julia.h>

// Fonction d'initialisation de Julia
void init_julia() {
    jl_init();
}

// Fonction pour évaluer une chaîne Julia
double eval_julia(const char *expr) {
    jl_value_t *result = jl_eval_string(expr);
    if (jl_typeis(result, jl_float64_type)) {
        return jl_unbox_float64(result);
    } else {
        fprintf(stderr, "Error: Expression did not evaluate to Float64\n");
        return 0.0;
    }
}

// Fonction pour arrêter Julia
void cleanup_julia() {
    jl_atexit_hook(0);
}
