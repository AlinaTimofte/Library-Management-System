<template>
  <div class="container mt-4">
    <h2 class="mb-4">AI Suggestions</h2>
    <div class="card">
      <div class="card-body">
        <div class="mb-3">
          <label for="prompt" class="form-label">Ask for book suggestions:</label>
          <textarea 
            id="prompt" 
            v-model="prompt" 
            class="form-control" 
            rows="3" 
            placeholder="e.g., What books should I add for sci-fi fans?"
          ></textarea>
        </div>
        <button @click="askAI" class="btn btn-primary" :disabled="loading">
          <span v-if="loading" class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
          {{ loading ? 'Asking AI...' : 'Ask AI' }}
        </button>
      </div>
    </div>

    <div v-if="response" class="mt-4">
      <div class="card">
        <div class="card-header">
          Suggestion
        </div>
        <div class="card-body">
          <p class="card-text" style="white-space: pre-wrap;">{{ response }}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'AISuggestionsView',
  data() {
    return {
      prompt: '',
      response: null,
      loading: false
    };
  },
  methods: {
    async askAI() {
      if (!this.prompt.trim()) return;
      
      this.loading = true;
      this.response = null;
      
      try {
        const res = await fetch(`http://localhost:8080/api/ai/ask?q=${encodeURIComponent(this.prompt)}`);
        const data = await res.json();
        this.response = data.answer;
      } catch (error) {
        console.error('Error asking AI:', error);
        this.response = 'Failed to get a response from the AI. Please try again.';
      } finally {
        this.loading = false;
      }
    }
  }
};
</script>

<style scoped>
.card {
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}
</style>
