package com.example.library.service;

import org.springframework.stereotype.Service;
import org.springframework.beans.factory.annotation.Value;
import java.util.Map;

@Service
public class AIService {
    @Value("${gemini.api.key}")
    private String apiKey;

    private final org.springframework.web.client.RestTemplate restTemplate = new org.springframework.web.client.RestTemplate();

    public String ask(String q) {
        String url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=" + apiKey;

        // Construct the JSON body
        Map<String, Object> part = Map.of("text", "Answer as a librarian suggesting books. " + q);
        Map<String, Object> content = Map.of("parts", java.util.List.of(part));
        Map<String, Object> body = Map.of("contents", java.util.List.of(content));

        try {
            org.springframework.http.HttpHeaders headers = new org.springframework.http.HttpHeaders();
            headers.setContentType(org.springframework.http.MediaType.APPLICATION_JSON);

            org.springframework.http.HttpEntity<Map<String, Object>> entity = new org.springframework.http.HttpEntity<>(body, headers);

            org.springframework.http.ResponseEntity<Map> response = restTemplate.postForEntity(url, entity, Map.class);
            Map resp = response.getBody();

            // Parse response
            if (resp != null && resp.containsKey("candidates")) {
                java.util.List candidates = (java.util.List) resp.get("candidates");
                if (!candidates.isEmpty()) {
                    Map candidate = (Map) candidates.get(0);
                    Map contentResp = (Map) candidate.get("content");
                    java.util.List parts = (java.util.List) contentResp.get("parts");
                    if (!parts.isEmpty()) {
                        Map partResp = (Map) parts.get(0);
                        return (String) partResp.get("text");
                    }
                }
            }
            return "No suggestion found.";
        } catch (Exception e) {
            e.printStackTrace();
            return "Error calling AI: " + e.getMessage();
        }
    }
}