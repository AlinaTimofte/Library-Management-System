package com.example.library.service;

import org.springframework.stereotype.Service;
import org.springframework.web.reactive.function.client.WebClient;
import java.util.Map;

@Service
public class AIService {
    private final WebClient client = WebClient.builder().baseUrl("http://localhost:11434").build();

    public String ask(String q){
        Map<String,Object> body = Map.of("model","llama3","prompt","Răspunde scurt: "+q,"stream",false);
        Map resp = client.post().uri("/api/generate").bodyValue(body).retrieve().bodyToMono(Map.class).block();
        return (String) resp.getOrDefault("response","N/A");
    }
}
