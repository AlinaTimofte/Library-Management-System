package com.example.library.controller;

import com.example.library.service.AIService;
import org.springframework.web.bind.annotation.*;
import java.util.Map;

@RestController
@RequestMapping("/api/ai")
@CrossOrigin(origins="http://localhost:5173")
public class AIController {
    private final AIService ai;
    public AIController(AIService ai){this.ai=ai;}

    @GetMapping("/ask")
    public Map<String,String> ask(@RequestParam String q){
        return Map.of("answer", ai.ask(q));
    }
}
